namespace Ichosys.DataModel.Tests.ModelMetadataExample
{
    public partial class Account
    {
        public string AccountNumber { get; set; }

        public AccountObject AccountNavigation { get; set; }

        public string AccountHolder { get; }
    }
}
