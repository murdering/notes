namespace DirectX.DesignPatterns.Builder.Models
{
    public abstract class IActorBuilder
    {
        protected Actor Actor = new Actor();

        public abstract void BuildGender();
        public abstract void BuildName();
        public abstract void BuildEye();

        public Actor GetActor()
        {
            return Actor;
        }
    }
}
