namespace WpfApp1.ViewModel
{
    public class FindPerson
    {
        int id;
        public FindPerson(int id)
        {
            this.id = id;
        }
        public bool PersonPredicate(Person person)
        {
            return person.Id == id;
        }
    }
}
