namespace Gringotts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using global::GringottsDatabase.Models;

    public partial class GringottsModel : DbContext
    {
        public GringottsModel()
            : base("name=GringottsContext")
        {
        }

        public virtual DbSet<WizardDeposit> WizardDeposits { get; set; }
    }
}
