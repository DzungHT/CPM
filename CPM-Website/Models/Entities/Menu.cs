namespace CPM_Website.Models
{
    public partial class Menu
    {
        public Menu()
        {
        }

        public int MenuID { get; set; }

        public int? MenuPID { get; set; }

        public string MenuPName { get; set; }

        public int? ApplicationID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FontIcon { get; set; }

        public string Url { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public int? Sort_Order { get; set; }

        public string Path { get; set; }

        public int? Status { get; set; }

        public virtual Application Application { get; set; }

    }
}
