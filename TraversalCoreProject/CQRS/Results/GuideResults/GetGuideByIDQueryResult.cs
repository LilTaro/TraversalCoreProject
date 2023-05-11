namespace TraversalCoreProject.CQRS.Results.GuideResults
{
    public class GetGuideByIDQueryResult
    {
        public int GuideID { get; set; }
        public string GuideName { get; set; }
        public string GuideDesc { get; set; }
        public string GuideImageUrl { get; set; }
    }
}
