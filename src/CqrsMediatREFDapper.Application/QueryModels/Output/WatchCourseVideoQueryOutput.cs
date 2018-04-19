namespace CqrsMediatREFDapper.Application.QueryModels.Output
{
    public sealed class WatchCourseVideoQueryOutput
    {
        public byte[] Video { get; private set; }

        public static WatchCourseVideoQueryOutput Create(byte[] video) =>
            new WatchCourseVideoQueryOutput { Video = video };
    }
}
