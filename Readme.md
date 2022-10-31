# Table of Contents
- [Table of Contents](#table-of-contents)
- [TetrisBot](#tetrisbot)
  - [Calibration mode](#calibration-mode)
  - [Playing the Tetris](#playing-the-tetris)
    - [How does it work?](#how-does-it-work)
  - [History](#history)
  - [Instalation](#instalation)
    - [First Method](#first-method)
    - [Second Method](#second-method)
    - [Third method](#third-method)

# TetrisBot
TetrisBot is a windows program that was made to play [Tetris online](https://www.min2win.ru/gms/3336.html). The program is written in c# .Net and can work on windows devises.

## Calibration mode
![](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/Calibration.gif?raw=true)

It is required to run a calibration before  using the program. To do so, you have to take screenshots (<kbd>Win</kbd>+<kbd>Shift</kbd>+<kbd>S</kbd> on Windows) of the [board and next figure filed](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/playingBoard.png?raw=true) and paste it to the [required spaces](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/image.png?raw=true), by clicking on them. Then, by pressing the <kbd>Run Calibration</kbd> button, start the calibration process. Likewise, you can adjust the pause between pressing keys on this tab, but 10 ms are Ok most of the time.
## Playing the Tetris
![](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/Playing2.gif?raw=true)

TetrisBot was designed to play only in [this Tetris](https://www.min2win.ru/gms/3336.html). Of course, the alghoritm is universal for all Tetris games, but the program is scanning field by taking screenshots, so it probably won't scan the field correctly in other Tetris games.

To start the TetrisBot, you have to run a calibration (when you first start the program), press the <kbd>Play</kbd> button and start the Tetris game on the site, by pressing any key.

In the display, you may find the `scanned field` witch shows how TetrisBot sees the board, `New figure` and `Next Figure` demonstrate the [IDs](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/shpora.png?raw=true) of figures that are falling now and going to fall after this one. The next line tells what program decided to do with the falling figure (positive move means to move right on N cells, negative - to the left, rotate means rotate figure N times)

### How does it work?

The Programm scans the [Board and Next figure filed](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/playingBoard.png?raw=true) and waits when the new falling figure will appear, after this TetrisBot is generating all possible ways how the figure can fall (all possible x positions and all possible rotations). For each of the variants it generates all possible ways how next figure can fall. 

After generating all variants it looks for the most suitable one, by using an estimation algorithm (like adding 90 points for fulled line and taking away 35 points for 'hole' in line). After Scoring algorithm, TetrisBot chooses the best way to put the figure and the cycle repeats

## History
The first version of the program was made in December 2020, it was console application. The main algorithm remained the same and most of it can be found in `Oldprogramm.cs`. In October 2022 the GUI and calibration mode were made.

## Instalation
### First Method
Click <kbd>Code</kbd> and then <kbd>Open in Visual Studio</kbd>
### Second Method
Open visual studio, press the <kbd>Clone repository</kbd> button and paste the URL of the repository `https://github.com/TheBestChelik/Tetris_Bot`
### Third method
Download the code and open `TetrisBot.sln`
