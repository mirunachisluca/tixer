using NanoidDotNet;

namespace Tixer.Helpers
{
    public static class IdGenerator
    {
        public static string Generate()
        {
            var id = Nanoid.Generate("1234567890abcdefhiklmnorstuv", 10);

            return id;
        }
    }
}
