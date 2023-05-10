namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationCommand
    {
        public DeleteDestinationCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
