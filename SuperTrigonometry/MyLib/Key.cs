namespace MyLib
{
    public delegate void ConvertRule(int Param);
    public class Key
    {
        public void KeyGen(int intN, ConvertRule cr)
        {
            cr(intN);
        }
    }
}
