package com.example.myapplication

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.DataSnapshot
import com.google.firebase.database.DatabaseError
import com.google.firebase.database.FirebaseDatabase
import com.google.firebase.database.ValueEventListener

class Fragment2 : Fragment() {
    lateinit var transactionsRecyclerView: RecyclerView
    lateinit var transactionsAdapter: TransactionsAdapter
    val transactionsList = mutableListOf<Transaction>()
    var totalIncome = 0
    var totalExpense = 0

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        // Inflate the layout for this fragment
        val view: View = inflater.inflate(R.layout.fragment_2, container, false)
        return view
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        transactionsRecyclerView = view.findViewById(R.id.transactionsRecyclerView)
        transactionsRecyclerView.layoutManager = LinearLayoutManager(requireContext())
        transactionsAdapter = TransactionsAdapter(transactionsList)
        transactionsRecyclerView.adapter = transactionsAdapter

        val deleteButton = view.findViewById<Button>(R.id.deleteButton)
        deleteButton.setOnClickListener {
            deleteAllTransactions()
        }

        val addTransactionButton = view.findViewById<Button>(R.id.addTransactionButton)
        addTransactionButton.setOnClickListener {
            val intent = Intent(requireContext(), AddTransactionActivity::class.java)
            intent.putExtra("totalincome",totalIncome)
            intent.putExtra("totalexpense",totalExpense)
            startActivity(intent)
        }

        fetchUserTransactions()
    }

    private fun deleteAllTransactions() {
        val currentUser = FirebaseAuth.getInstance().currentUser
        val userId = currentUser?.uid

        if (userId != null) {
            val database = FirebaseDatabase.getInstance().reference
            val userTransactionsRef = database.child("Transactions").child(userId)

            userTransactionsRef.removeValue()
                .addOnSuccessListener {
                    Toast.makeText(requireContext(), "All transactions deleted successfully", Toast.LENGTH_SHORT).show()
                }
                .addOnFailureListener {
                    Log.e("firebase", "Error deleting transactions: ${it.message}", it)
                    Toast.makeText(requireContext(), "Failed to delete transactions", Toast.LENGTH_SHORT).show()
                }
        }
    }

    private fun fetchUserTransactions() {
        val currentUser = FirebaseAuth.getInstance().currentUser
        val userId = currentUser?.uid
        val database = FirebaseDatabase.getInstance().reference
        val userTransactionsRef = database.child("Transactions").child(userId ?: "")

        userTransactionsRef.addValueEventListener(object : ValueEventListener {
            override fun onDataChange(snapshot: DataSnapshot) {
                transactionsList.clear()
                totalIncome = 0
                totalExpense = 0

                for (transactionSnapshot in snapshot.children) {
                    val transaction = transactionSnapshot.getValue(Transaction::class.java)
                    transaction?.let {
                        transactionsList.add(transaction)
                        if (transaction.type == "Income") {
                            totalIncome += transaction.amount.toInt()
                        } else if (transaction.type == "Expense") {
                            totalExpense += transaction.amount.toInt()
                        }
                    }
                }
                transactionsAdapter.notifyDataSetChanged()

                updateBalance()
            }

            override fun onCancelled(error: DatabaseError) {
                val errorMessage = "Error fetching transactions: ${error.message}"
                Toast.makeText(requireContext(), errorMessage, Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun updateBalance() {
        val incomeValueTextView = view?.findViewById<TextView>(R.id.incomeValue)
        val expenseValueTextView = view?.findViewById<TextView>(R.id.expenseValue)
        val balanceValueTextView = view?.findViewById<TextView>(R.id.balanceValue)

        incomeValueTextView?.text = totalIncome.toString()
        expenseValueTextView?.text = totalExpense.toString()

        val balance = totalIncome - totalExpense
        balanceValueTextView?.text = balance.toString()
    }
}
