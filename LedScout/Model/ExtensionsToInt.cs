namespace LedScout.Model
{
    public static class ExtensionsToInt 
    {    
        public static int ToPct(this int input) 
        {
            return input  * 100 / 255; 
        }
    }
}
