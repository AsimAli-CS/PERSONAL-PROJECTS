package com.example.myapplication

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentTransaction
class MainActivity : AppCompatActivity(), View.OnClickListener {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val fragment2Btn:Button = findViewById(R.id.showTransactions)
        fragment2Btn.setOnClickListener(this)
        val fragment1Btn:Button = findViewById(R.id.frag1_btn)
        fragment1Btn.setOnClickListener(this)
    }
    override fun onClick(v: View?) {
        val ft:FragmentTransaction =
            supportFragmentManager.beginTransaction()
        var fragment: Fragment? = null
        val vid = v?.id
        if(vid == R.id.frag1_btn){
            fragment = Fragment1();
        }
        else {
            fragment = Fragment2();
        }
        ft.replace(R.id.fragments, fragment);
        ft.commit();
    }
}