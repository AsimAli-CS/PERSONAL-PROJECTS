package com.example.myapplication
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.google.firebase.auth.FirebaseAuth

class LoginActivity : AppCompatActivity(){

    private lateinit var editTextUsername: EditText
    private lateinit var editTextPassword: EditText
    private lateinit var signInButton: Button
    private lateinit var auth: FirebaseAuth

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        editTextUsername= findViewById(R.id.editTextUsername)
        editTextPassword = findViewById(R.id.editTextPassword)
        signInButton = findViewById(R.id.buttonSignIn)
        auth = FirebaseAuth.getInstance()

        signInButton.setOnClickListener {
            val email = editTextUsername.text.toString()
            val password = editTextPassword.text.toString()

            if (email.isNotEmpty() && password.isNotEmpty()) {
                authenticateUser(email,password)
            } else {
                Toast.makeText(
                    this@LoginActivity,
                    "Please enter both email and password.",
                    Toast.LENGTH_SHORT
                ).show()
            }
        }


        val signUpLink = findViewById<TextView>(R.id.signUplink)
        signUpLink.setOnClickListener {
            val intent = Intent(this, SignUpActivity::class.java)
            startActivity(intent)
        }


    }

    private fun authenticateUser(email: String, password: String) {
        auth.signInWithEmailAndPassword(email, password)
            .addOnCompleteListener(this) { task ->
                if (task.isSuccessful) {
                    val user = auth.currentUser
                    Log.d("Login", "${user?.email} successfully logged in.")
                    Toast.makeText(
                        this@LoginActivity,
                        "Authentication successful.",
                        Toast.LENGTH_SHORT
                    ).show()
                    val intent = Intent(this@LoginActivity, WelcomeActivity::class.java)
                    startActivity(intent)
                    // You can navigate to another activity upon successful authentication if needed
                    // For example, navigate to HomeActivity
                    // val intent = Intent(this@LoginActivity, HomeActivity::class.java)
                    // startActivity(intent)
                } else {
                    Log.e("Login", "failure", task.exception)
                    Toast.makeText(
                        this@LoginActivity,
                        "Authentication failed.",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            }
    }
}
