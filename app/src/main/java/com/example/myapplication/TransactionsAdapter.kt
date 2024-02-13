package com.example.myapplication

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class TransactionsAdapter(private val transactionsList: MutableList<Transaction>) : RecyclerView.Adapter<TransactionsAdapter.ViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.transaction_item, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val transaction = transactionsList[position]
        holder.bind(transaction)
    }

    override fun getItemCount(): Int {
        return transactionsList.size
    }

    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        private val amountTextView: TextView = itemView.findViewById(R.id.transactionAmountTextView)
        private val descriptionTextView: TextView = itemView.findViewById(R.id.transactionDescriptionTextView)
        private val typeTextView: TextView = itemView.findViewById(R.id.transactionTypeTextView)
        private val DateTextView: TextView = itemView.findViewById(R.id.transactionDateTextView)
        fun bind(transaction: Transaction) {
            amountTextView.text = transaction.amount
            descriptionTextView.text = transaction.description
            typeTextView.text = transaction.type
            DateTextView.text=transaction.date.toString()
        }
    }
}
