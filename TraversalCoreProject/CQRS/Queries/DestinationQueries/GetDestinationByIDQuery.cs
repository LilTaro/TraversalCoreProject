namespace TraversalCoreProject.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int ID)
        {
            this.ID = ID;
        }

        public int ID { get; set; }
    }
}
