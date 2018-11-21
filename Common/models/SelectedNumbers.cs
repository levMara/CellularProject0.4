namespace Common
{
    public class SelectedNumbers
    {
        public int SelectedNumbersID { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }

        public virtual PackageInclude PackageInclude { get; set; }
    }
}