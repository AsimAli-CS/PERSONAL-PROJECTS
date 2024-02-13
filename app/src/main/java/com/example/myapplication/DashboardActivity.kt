package com.example.myapplication
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.DataSnapshot
import com.google.firebase.database.DatabaseError
import com.google.firebase.database.FirebaseDatabase
import com.google.firebase.database.ValueEventListener

class DashboardActivity : AppCompatActivity() {

    private lateinit var transactionsRecyclerView: RecyclerView
    private lateinit var transactionsAdapter: TransactionsAdapter
    private val transactionsList = mutableListOf<Transaction>()
    private var totalIncome = 0
    private var totalExpense = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_dashboard)

        transactionsRecyclerView = findViewById(R.id.transactionsRecyclerView)
        transactionsRecyclerView.layoutManager = LinearLayoutManager(this)
        transactionsAdapter = TransactionsAdapter(transactionsList)
        transactionsRecyclerView.adapter = transactionsAdapter

        val deleteButton = findViewById<Button>(R.id.deleteButton)
        deleteButton.setOnClickListener {
            deleteAllTransactions()
        }

        val addTransactionButton = findViewById<Button>(R.id.addTransactionButton)
        addTransactionButton.setOnClickListener {
            val intent = Intent(this, AddTransactionActivity::class.java)
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
                    Toast.makeText(this@DashboardActivity, "All transactions deleted successfully", Toast.LENGTH_SHORT).show()
                }
                .addOnFailureListener {
                    Log.e("firebase", "Error deleting transactions: ${it.message}", it)
                    Toast.makeText(this@DashboardActivity, "Failed to delete transactions", Toast.LENGTH_SHORT).show()
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
                Toast.makeText(this@DashboardActivity, errorMessage, Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun updateBalance() {
        val incomeValueTextView = findViewById<TextView>(R.id.incomeValue)
        val expenseValueTextView = findViewById<TextView>(R.id.expenseValue)
        val balanceValueTextView = findViewById<TextView>(R.id.balanceValue)

        incomeValueTextView.text = totalIncome.toString()
        expenseValueTextView.text = totalExpense.toString()

        val balance = totalIncome - totalExpense
        balanceValueTextView.text = balance.toString()
    }
}
