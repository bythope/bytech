using System;

namespace Bythope.Bytech.Demo {
    public static class Program {
        [STAThread]
        static void Main() {
            using (new DemoApplication()) { }
                
        }
    }
}
