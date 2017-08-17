using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tracing
{
    public partial class TracingWebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void CreatePerson()
        {
            List<Person> person = new List<Person>();
            person.Add(new Person
            {
                FirstName = "John",
                LastName = "Doe"
            });
            Session["Person"] = person;
            if (Trace.IsEnabled)
                Trace.Write("Session Created");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            CreatePerson();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var person = ((List<Person>)Session["Person"]);
            try
            {
                person.RemoveAt(0);
                Trace.Write("deleted");
            }
            catch (Exception ex)
            {
                Trace.Warn(ex.Message);
            }
            Session["Person"] = person;

        }
    }
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(FirstName, LastName);
            }
            set
            {
                FullName = string.Concat(FirstName, LastName);
            }
        }

    }
}