namespace DirectX.DesignPatterns.Builder.Models
{
    public class Director
    {
        public Actor CreateActor(IActorBuilder builder)
        {
            builder.BuildEye();
            builder.BuildGender();
            builder.BuildName();

            return builder.GetActor();
        }
    }
}
