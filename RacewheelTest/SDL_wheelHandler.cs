using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;


namespace racingwheelTest
{
    internal class SDL_wheelHandler
    {

        public bool WheelInitializedFlag { get; private set; }
        public bool SDL_RunningFlag { get; private set; }



        public SDL_wheelHandler()
        {
            this.WheelInitializedFlag = false;
            this.SDL_RunningFlag = false;
        }


        public bool SDL_wheelInit()
        {
            // Initilizes SDL
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_JOYSTICK) < 0)
            {
                Console.WriteLine($"There was an issue initilizing SDL. {SDL.SDL_GetError()}");
            }
            else
            {

                // Create a new window given a title, size, and passes it a flag indicating it should be shown.
                /*var window = SDL.SDL_CreateWindow("SDL .NET 6 Tutorial", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

                if (window == IntPtr.Zero)
                {
                    Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
                }

                // Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
                var renderer = SDL.SDL_CreateRenderer(window,
                                                        -1,
                                                        SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                                                        SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

                if (renderer == IntPtr.Zero)
                {
                    Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");
                }

                // Initilizes SDL_image for use with png files.
                if (SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_PNG) == 0)
                {
                    Console.WriteLine($"There was an issue initilizing SDL2_Image {SDL_image.IMG_GetError()}");
                }
                */

                var gGameController = IntPtr.Zero;
                //Check for joysticks
                if (SDL.SDL_NumJoysticks() < 1) //err
                {
                    Console.WriteLine("Warning: No game controller connected!");
                }
                else  // ok
                {
                    Console.WriteLine($"Number of connected game controllers {SDL.SDL_NumJoysticks()} ");

                    //Load game controller 
                    int gameControlerNo = 0;
                    if (SDL.SDL_IsGameController(gameControlerNo) == SDL.SDL_bool.SDL_TRUE)
                    {
                        gGameController = SDL.SDL_JoystickOpen(gameControlerNo);
                        if (gGameController == IntPtr.Zero)
                        {
                            Console.WriteLine($"Could not open gamecontroller no. {gameControlerNo} {SDL.SDL_GetError()} ");
                        }
                    }
                    else
                    {
                        // opened successfully game controller
                        Console.WriteLine($"game controller no. {gameControlerNo}");
                        this.WheelInitializedFlag = true;
                        this.SDL_RunningFlag = true;
                    }
                }

            }
            return this.WheelInitializedFlag;
        }


        public void SDL_wheelEvent()
        {
            // Check to see if there are any events and continue to do so until the queue is empty.
            while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        this.SDL_RunningFlag = false;
                        break;
                    case SDL.SDL_EventType.SDL_JOYAXISMOTION:
                        Console.WriteLine($"controller no.: {e.jaxis.which} axis: {e.jaxis.axis} value: {e.jaxis.axisValue}");
                        break;
                    default:
                        Console.WriteLine($"value: {e.type} ");
                        break;

                }
            }
        }






    }
}
