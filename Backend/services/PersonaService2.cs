namespace Backend.services
{
    public class PersonaService2 : IPersonaServices
    {
       public  bool validate(PersonaDatos persona) {
            if (string.IsNullOrEmpty(persona.name) || persona.name.Length > 100 || persona.name.Length < 3){
                return false;
            }
            return true;
        }
    }
}
