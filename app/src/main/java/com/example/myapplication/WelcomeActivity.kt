package com.example.myapplication
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler

class WelcomeActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_welcome)

        Handler().postDelayed({
            // Create an Intent to start the next activity
            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)

            // Finish the current activity to prevent going back to it
            finish()
        }, 2000)
    }
}