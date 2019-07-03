namespace DirectX.DesignPatterns.Builder.Models
{
    public class YaHahaBuilder : IActorBuilder
    {
        public override void BuildEye()
        {
            Actor.Eye = "Blue";
        }

        public override void BuildGender()
        {
            Actor.Gender = "Femal";
        }

        public override void BuildName()
        {
            Actor.Name = "Yaha";
        }
    }
}
