namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public int DestinationID { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationTime { get; set; }
        public double DestinationPrice { get; set; }
        public int Capacity { get; set; }
    }
}
