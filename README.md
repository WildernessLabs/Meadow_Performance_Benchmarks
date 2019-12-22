# Meadow Performance Benchmarks

Contains applications that measure the performance of Meadow, as well as the results of those tests.

This is primarily to track the progress of our performance improvements; Meadow is currently slow because it executes .NET IL code in its interpreter. 

## Benchmark Results

### Pi Calculation

Calculates pi (`3.14159..`) to [`x`] digits and records the amount of time it takes.

| Operation          | **b3.5**    | **b3.6**    |
|--------------------|-------------|-------------|
| 50 digit Pi calc   | `11s`       | `11s`       |
| 100 digit Pi calc  | `54s`       | `54s`       |
| 150 digit Pi calc  | `127s`      | `126s`      |
 
### List Operations

Create a 1,000 item `List<int>`, and do perform basic list operations on it.

| Operation          | **b3.5**   | **b3.6**   |
|--------------------|------------|------------|
| List instantiation | `30ms`     | `30ms`     |
| List population    | `120ms`    | `120ms`    |
| List summation     | `130ms`    | `120ms`    |
| List clearing      | `59s`      | `59s`      |

### Digital Output Port Operations

Initializes three `DigitalOutputPort` instances, one for each of the onboard LED components and 
writes to them.

| Operation              | **b3.5**  | **b3.6**  |
|------------------------|-----------|-----------|
| Port initialization    | `2.7s`    | `2.8s`    |
| 300 Port writes        | `48s`     | `13s`     |
| Average time per write | `15.9ms`  | `4.2ms`   |

### SoftPwmGeneration

Generates a PWM signal in software. Currently is a visual test. Run the test and note which was 
the last frequency change that was noticeable.

| Operation                        | **b3.5** | **b3.6** |
|----------------------------------|----------|----------|
| Maximum Frequency @ `50%` duty   | ~`50hz`  | ~`50hz`  |
