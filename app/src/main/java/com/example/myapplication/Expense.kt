package com.example.myapplication

import java.util.Date

class Transaction(var uId: String, var amount: String, var description: String, var type: String, var date: Date?) {
    constructor() : this("", "", "", "", Date()) // Secondary constructor with a non-null Date instance
}