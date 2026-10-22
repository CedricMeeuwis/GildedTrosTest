namespace GildedTros.App
{
    public static class BoolExtension
    {
        //Way to go from bool to int while avoiding casting
        public static int ToInt(this bool Value)
        {
            return Value ? 1 : 0;
        }
    }
}
