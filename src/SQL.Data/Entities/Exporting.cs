namespace SQL.Data.Entities
{
    public interface Exporting
    {
        void Accept(Visitor visitor);
    }
}
