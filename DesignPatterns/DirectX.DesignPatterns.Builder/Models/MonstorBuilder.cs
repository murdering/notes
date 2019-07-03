namespace DirectX.DesignPatterns.Builder.Models
{
    public class MonstorBuilder : IActorBuilder
    {
        public override void BuildEye()
        {
            Actor.Eye = "Brown";
        }

        public override void BuildGender()
        {
            Actor.Gender = "Unknow";
        }

        public override void BuildName()
        {
            Actor.Name = "Monster";
        }
    }
}
