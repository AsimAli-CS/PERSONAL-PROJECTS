package com.example.myapplication

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.FirebaseDatabase
import java.util.Date

class AddTransactionActivity: AppCompatActivity() {

    private lateinit var userId: String

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add_transaction)


        val inputAmount = findViewById<EditText>(R.id.editTextAmount)
        val inputDescription = findViewById<EditText>(R.id.editTextDescription)

        val checkBoxIncome: CheckBox = findViewById(R.id.checkBoxIncome)
        val checkBoxExpense: CheckBox = findViewById(R.id.checkBoxExpense)

// Use the checked status as needed
        val currentUser = FirebaseAuth.getInstance().currentUser
        if (currentUser != null) {
            userId = currentUser.uid // Retrieve the user ID
        }
        else {
            // Handle case where user is not logged in
        }

        val btnSubmit = findViewById<Button>(R.id.submitButton)
        btnSubmit.setOnClickListener(View.OnClickListener {
            val currentDate = Date()
            val amount = inputAmount.text.toString().trim()
            val description = inputDescription.text.toString().trim()
            // Get the checked status of the checkboxes
            val isIncomeChecked: Boolean = checkBoxIncome.isChecked
            val isExpenseChecked: Boolean = checkBoxExpense.isChecked

            val intent=Intent()
            var totalincome:Int= intent.getStringExtra("totalincome")?.toIntOrNull() ?: 0
            var totalexpense:Int= intent.getStringExtra("totalexpense")?.toIntOrNull() ?: 0
            val type = if (isIncomeChecked) {
                "Income"
            } else if (isExpenseChecked) {
                "Expense"
            } else {
                // Handle case where neither checkbox is checked
                "else"
            }
            if (type=="Income")
                totalincome+=amount.toInt()
            else if (type=="Expense")
                totalexpense+=amount.toInt()
            if(totalexpense <= totalincome)
            submitData(Transaction(userId,amount,description,type,currentDate))
            else
                Toast.makeText(this, "expense greater than income", Toast.LENGTH_SHORT).show()
        })
    }





    fun submitData(transaction: Transaction) {
        val currentUser = FirebaseAuth.getInstance().currentUser
        val userId = currentUser?.uid

        if (userId != null) {
            val database = FirebaseDatabase.getInstance().reference
            val userTransactionsRef = database.child("Transactions").child(userId)
            val newTransactionRef = userTransactionsRef.push()

            newTransactionRef.setValue(transaction)
                .addOnSuccessListener {
                    Toast.makeText(this@AddTransactionActivity, "Data stored successfully", Toast.LENGTH_SHORT).show()
                }
                .addOnFailureListener {
                    Log.e("firebase", "Error storing data: ${it.message}", it)
                    Toast.makeText(this@AddTransactionActivity, "Failed to store data", Toast.LENGTH_SHORT).show()
                }
        }
    }


}

