# MasonMelting

![Mason Melting](https://i.ibb.co/xgGrVTY/Mason-Melting.png)

## Description

MasonMelting is a malicious program designed to create destructive effects on the system. This program writes random data to the Master Boot Record (MBR) of the computer, leading to system corruption. Additionally, the program randomly moves the cursor and blocks user input.

### Copyright

This program was developed by **ABOLHB**.

## Explanation

### How does the program work?

1. **Writing to MBR**: 
   - The program uses the `OverwriteMBR` function to open the physical drive (PhysicalDrive0) and write random 512-byte data. This process damages the boot record of the computer.

2. **Moving the Cursor**: 
   - The program uses `GetCursorPos` to get the current position of the cursor, then moves it randomly using `SetCursorPos`.
   - User input is blocked by `BlockInput(true)` during the execution of the movements.
   - The program copies the screen content and displays it randomly using `BitBlt`.

3. **Infinite Loop**: 
   - The program iterates in an infinite loop, meaning it will continue executing the above actions until forcefully stopped.

### Disclaimer

This program is intended for educational purposes only. **ABOLHB** does not bear any responsibility for damages resulting from the use of this program. It is strongly warned against using it on unauthorized systems or for illegal purposes. Make sure to use it only in safe testing environments.

## How to Use

No usage information is provided for this program, as it is malicious software. It should not be run on real systems or used for any illegal activity.
