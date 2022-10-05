using SDL2;
using System;

//Analog joystick dead zone
const int JOYSTICK_DEAD_ZONE = 8000;

var running = true;

// Main loop for the program
while (running)
{

    /*
    // Sets the color that the screen will be cleared with.
    if (SDL.SDL_SetRenderDrawColor(renderer, 135, 206, 235, 255) < 0)
    {
        Console.WriteLine($"There was an issue with setting the render draw color. {SDL.SDL_GetError()}");
    }

    // Clears the current render surface.
    if (SDL.SDL_RenderClear(renderer) < 0)
    {
        Console.WriteLine($"There was an issue with clearing the render surface. {SDL.SDL_GetError()}");
    }
    */
    // Switches out the currently presented render surface with the one we just did work on.
    //SDL.SDL_RenderPresent(renderer);
}

// Clean up the resources that were created.
//SDL.SDL_DestroyRenderer(renderer);
//SDL.SDL_DestroyWindow(window);
//Close game controller
SDL.SDL_JoystickClose(gGameController);
SDL.SDL_Quit();