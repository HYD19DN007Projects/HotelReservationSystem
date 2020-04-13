namespace Team_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblPayment
    {
        public int TransactionID { get; set; }
        public string Customer_ID { get; set; }
        public string Bank_ID { get; set; }
        [Required(ErrorMessage = "Credit Card Number is must")]
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "Credit Card Number is not in correct format")]
        public long Credit_card_Number { get; set; }
        [Required(ErrorMessage = "CardType is must")]
        public string Card_Type { get; set; }
        [Required(ErrorMessage = "Name On Card is must")]
        [RegularExpression("^[a-zA-Z]{0,30}$", ErrorMessage = "Enter only Alphabets")]
        public string Name_on_Card { get; set; }
        [Required(ErrorMessage = "Date of Transaction is must")]
        public System.DateTime Date_of_Transaction { get; set; }
        [Required(ErrorMessage = "Expiry Date is must")]
        [RegularExpression("^[0-1]{1}[0-9]{1}/[0-9]{2}$", ErrorMessage = "Expiry Date is not in correct format ")]
        public string Expiry_Date { get; set; }
        [Required(ErrorMessage = "Cvv is must")]
        [RegularExpression("^[0-9]{3}$", ErrorMessage = "Cvv is not in correct format")]
        public int CVV_Number { get; set; }
        [Required(ErrorMessage = "Account Number is must")]
        [RegularExpression("^[0]{2}[0-9]{8}$", ErrorMessage = "Account Number is not in correct format")]
        public string Account_Number { get; set; }
        [Required(ErrorMessage = "Pin Number is must")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Pin Number is not in correct format")]
        public int Pin_Number { get; set; }
        public int Amount { get; set; }

        public virtual tblBankDetail tblBankDetail { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }
    }
}



