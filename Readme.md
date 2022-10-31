# TetrisBot
TetrisBot is a windows programm that was made to play [tetris online](https://www.min2win.ru/gms/3336.html). The programm is written in c# .Net and can work on windows devises.

## Calibration mode
![](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/Calibration.gif?raw=true)

It is required to run calibration before usage the programm. To do so, you have to take screenshots (<kbd>Win</kbd>+<kbd>Shift</kbd>+<kbd>S</kbd> on Windows) of the [board and next figure filed](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/playingBoard.png?raw=true) and paste it to the [required spaces](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/image.png?raw=true), by clicking on them. Then, by pressing the <kbd>Run Calibration</kbd> button, start the calibration process. Likewise you can adjust the pause betweenpressing keys in this tab, but 10 ms is Ok most of the time.
## Playing the tetris
![](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/Playing.gif?raw=true)

TetrisBot was designed to play only in [this tetris](https://www.min2win.ru/gms/3336.html). Of course, alghoritm is universal for all tetris games, but the programm is scaning field by taking screenshots, so it probably won't scan the field correctly in other tetris games.

To start the TetrisBot, you have to run calibration (when you first start the program), press <kbd>Play</kbd> button and start the tetris game on the site, by pressing any key.

In the displya, you may find the `scanned field` witch shows how TetrisBot sees the board, `New figure` and `Next Figure` demonstrate the [IDs](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/shpora.png?raw=true) of figures that are falling now and going to fall after this one. The next line tells what program decided to do with the falling figure (positive move means to move righht on N cells, negtive - to the left, rotate means rotate figure N times)

### How does it work?

The Programm scans the [Board and Next figure filed](https://github.com/TheBestChelik/Tetris_Bot/blob/master/img/playingBoard.png?raw=true) and waits when the new falling figure will appear, after this TetrisBot is generating all possible ways how the figure can fall (all possible x positions and all possible rotations). For each of the variants it genarates all possible ways how next figure can fall. 

After generating all varients it looks for the most suitable, using estimation algorithm (like adding 90 points for fulled line and taking away 35 points for 'hole' in line). After Scoring alghoritm, TetrisBot choses the best way to put the figure and cycle repeats

## History
The first version of programm was made in December 2020, it was consolle app. The main alghoritm remained the same and most of it can be found in `Oldprogramm.cs`. In October 2022 the GUI and calibraton mode were made.
