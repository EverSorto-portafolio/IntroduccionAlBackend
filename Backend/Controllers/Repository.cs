namespace Backend.Controllers
{
    public class Repository
    {
        public static List<PersonaDatos> persona = new List<PersonaDatos> {
        new PersonaDatos(){
            id = 1,
            age= new DateTime(1994,08,03),
            name="Ever Alfredo sorto"
        },
        new PersonaDatos(){
            id = 2,
            age= new DateTime(1994,09,03),
            name=" Alfredo sorto"
        },
        new PersonaDatos(){
            id = 3,
            age= new DateTime(1994,11,03),
            name="Sorto"
        }

        };

        
    }
}

public class PersonaDatos { 

    public int id {get;set;}
    public string name {get;set;}
    public DateTime age {get;set;}


}
