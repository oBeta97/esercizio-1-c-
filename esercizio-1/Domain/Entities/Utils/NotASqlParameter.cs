namespace esercizio_1.Entities.Utils
{
    // Classe per evitare che dei parametri vengano considerati SQL Parameter
    public class NotASqlParameter
    {
        // Costruttore privato, solo all'interno della classe può essere invocato
        private NotASqlParameter(string value)
        {
            Value = value;
        }
        public string Value { get; }

        // Operatore di conversione esplicita!
        // Quando si va a scrivere {pluto = (NotASqlParameter) pippo;} viene invocato questo metodo che va ad istanziare un nuovo oggetto NotASqlParameter
        public static explicit operator NotASqlParameter(string value) => new(value);
        public override string ToString()
        {
            return this.Value;
        }
    }
}