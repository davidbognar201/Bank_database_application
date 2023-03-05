using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class BankCard
    {
    

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        public string Type { get; set; }
        public bool IsBlocked { get; set; }
        public string CardNumber { get; set; }
        public int AttachedAccountId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CurrentAccount AttachedAccount { get; set; }

        public BankCard(int cardId, string cardNumber, string type, bool isBlocked, int attachedAccountId)
        {
            CardId = cardId;
            CardNumber = cardNumber;
            Type = type;
            IsBlocked = isBlocked;
            AttachedAccountId = attachedAccountId;
        }
        public BankCard()
        {

        }

        public override string ToString()
        {
            return $"{CardId} -- {CardNumber} -- {AttachedAccount.AccountOwner.CustName}";
        }

        public override bool Equals(object obj)
        {
            return obj is BankCard card &&
                   CardId == card.CardId &&
                   Type == card.Type &&
                   IsBlocked == card.IsBlocked &&
                   CardNumber == card.CardNumber &&
                   AttachedAccountId == card.AttachedAccountId &&
                   EqualityComparer<CurrentAccount>.Default.Equals(AttachedAccount, card.AttachedAccount);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CardId, Type, IsBlocked, CardNumber, AttachedAccountId, AttachedAccount);
        }
    }
}
