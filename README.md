# Meadow Performance Benchmarks

Contains applications that measure the performance of Meadow, as well as the results of those tests.

This is primarily to track the progress of our performance improvements; Meadow is currently slow because it executes .NET IL code in its interpreter. 

## Benchmark Results

### Pi Calculation

Calculates pi (`3.14159..`) to [`x`] digits and records the amount of time it takes.

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   |
|--------------------|------------|------------|------------|
| 50 digit Pi calc   | `11s`      | `11s`      | `2.3s`     |
| 100 digit Pi calc  | `54s`      | `54s`      | `10.8s`    |
| 150 digit Pi calc  | `127s`     | `126s`     | `24.4s`    |

 
### List Operations

Create a 1,000 item `List<int>`, and do perform basic list operations on it.

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   | **b4.3**   | **b5.1**   |
|--------------------|------------|------------|------------|------------|------------|
| List instantiation | `30ms`     | `30ms`     | `30ms`     | `19ms`     | `10ms`     |
| List population    | `120ms`    | `120ms`    | `20ms`     | `44ms`     | `20ms`     |
| List summation     | `130ms`    | `120ms`    | `30ms`     | `21ms`     | `19ms`     |
| List clearing      | `59s`      | `59s`      | `7.7s`     | `6.1s`     | `7.1s`     |

### Digital Output Port Operations

Initializes three `DigitalOutputPort` instances, one for each of the onboard LED components and 
writes to them.

| Operation              | **b3.5**  | **b3.6**  | **b3.7**  | **b4.3**  | **b5.1**  |
|------------------------|-----------|-----------|-----------|-----------|-----------|
| Port initialization    | `2.7s`    | `2.8s`    | `2.0s`    | `0.5s`    | `0.45s`   |
| 300 Port writes        | `48s`     | `13s`     | `0.15s`   | `1.4s`    | `1.33s`   |
| Average time per write | `159ms`   | `42ms`    | `0.5ms`   | `0.5ms`   | `0.44ms`  |

### SoftPwmGeneration

Generates a PWM signal in software. Currently is a visual test. Run the test and note which was 
the last frequency change that was noticeable.

| Operation                        | **b3.5** | **b3.6** | **b3.7** | **b4.3** | **b5.1** |
|----------------------------------|----------|----------|----------|----------|----------|
| Maximum Frequency @ `50%` duty   | ~`50hz`  | ~`50hz`  | ~`100hz` | ~`100hz` | ~`100hz` |
