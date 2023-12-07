using Microsoft.Xna.Framework.Input;

namespace Test
{
    internal class InputManager
    {
        public static KeyboardState CurrentKeyState { get; private set; }
        public static KeyboardState PreviousKeyState { get; private set; }

        public static void Update()
        {
            PreviousKeyState = CurrentKeyState;
            CurrentKeyState = Keyboard.GetState();
        }

        public static bool KeyDown(Keys key)
        {
            return CurrentKeyState.IsKeyDown(key);
        }

        public static bool KeyPushed(Keys key)
        {
            return CurrentKeyState.IsKeyDown(key) && !PreviousKeyState.IsKeyDown(key);
        }
    }
}
