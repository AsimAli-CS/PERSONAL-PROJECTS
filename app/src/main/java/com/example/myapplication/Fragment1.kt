package com.example.myapplication

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.DataSnapshot
import com.google.firebase.database.DatabaseError
import com.google.firebase.database.FirebaseDatabase
import com.google.firebase.database.ValueEventListener

class Fragment1() : Fragment() {
    var totalIncome = 0
    var totalExpense = 0
    override fun onCreateView(
        inflater: LayoutInflater,
        viewGroup: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_1, viewGroup, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        fetchUserTransactions()
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



    private fun fetchUserTransactions() {
        val currentUser = FirebaseAuth.getInstance().currentUser
        val userId = currentUser?.uid
        val database = FirebaseDatabase.getInstance().reference
        val userTransactionsRef = database.child("Transactions").child(userId ?: "")

        userTransactionsRef.addValueEventListener(object : ValueEventListener {
            override fun onDataChange(snapshot: DataSnapshot) {
                totalIncome = 0
                totalExpense = 0

                for (transactionSnapshot in snapshot.children) {
                    val transaction = transactionSnapshot.getValue(Transaction::class.java)
                    transaction?.let {
                        if (transaction.type == "Income") {
                            totalIncome += transaction.amount.toInt()
                        } else if (transaction.type == "Expense") {
                            totalExpense += transaction.amount.toInt()
                        }
                    }
                }

                updateBalance()
            }

            override fun onCancelled(error: DatabaseError) {
                val errorMessage = "Error fetching transactions: ${error.message}"
                Toast.makeText(requireContext(), errorMessage, Toast.LENGTH_SHORT).show()
            }
        })
    }



}