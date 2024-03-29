<img src="design/banner.jpg" style="margin-bottom:10px" />

# Meadow_Performance_Benchmarks

Contains applications that measure the performance of Meadow, as well as the results of those tests.

This is primarily to track the progress of our performance improvements.

To validate, make sure to run application in `release` mode.

**Please Note** - Small variances will occur between runs and between boards.

## Benchmark results

Below this markdown you will see the kinds of tests we perform on our boards to benchmark its performance for each release.

* [Pi Calculation](#pi-calculation)
* [List Benchmark](#list-benchmark)
* [Digital Output Operations](#digital-output-port-operations)
* [Soft PWM Generation](#soft-pwm-generation)

## Pi Calculation

Calculates pi (`3.14159..`) to [`x`] digits and records the amount of time (in seconds) it takes. Here are the results per release:

| Operation              | **b3.5**   | **b3.6**   | **b3.7**   | **b6.0.1** | **b6.3**   | **RC1**   | **RC1 w/ JIT** | **RC-2** | **RC-3** |
|------------------------|------------|------------|------------|------------|------------|-----------|----------------|----------|----------|
| Calculate 50 digits    | `11s`      | `11s`      | `2.3s`     | `1.8s`     | `1.7s`     | `2.3s`    | `2.3s`         | `2.2s`   | `2.5s`   |
| Calculate 100 digits   | `54s`      | `54s`      | `10.8s`    | `8.9s`     | `8.3s`     | `11.2s`   | `11.1s`        | `10.1s`  | `11.9s`  |
| Calculate 150 digits   | `127s`     | `126s`     | `24.4s`    | `20.6s`    | `19.3s`    | `26.3s`   | `25.8s`        | `23.4s`  | `27.9s`  |

![Pi Calculation](design/pi-calculation.png#gh-light-mode-only)![Pi Calculation](design/pi-calculation-dark.png#gh-dark-mode-only)
 
## List Benchmark

### List Operations

Create a 1,000 item `List<int>`, and perform basic list operations on it.

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   | **b4.3**   | **b5.1**   | **b6.0.1** | **b6.3**   | **RC1**   | **RC1+JIT** | **RC-2**  | **RC-3**  |
|--------------------|------------|------------|------------|------------|------------|------------|------------|-----------|-------------|-----------|-----------|
| Instantiation      | `30ms`     | `30ms`     | `30ms`     | `19ms`     | `10ms`     | `11ms`     | `11ms`     | `5ms`     | `13ms`      | `14ms`    | `15ms`    |
| Population         | `120ms`    | `120ms`    | `20ms`     | `44ms`     | `20ms`     | `21ms`     | `10ms`     | `21ms`    | `28ms`      | `29ms`    | `31ms`    |
| Summation          | `130ms`    | `120ms`    | `30ms`     | `21ms`     | `19ms`     | `19ms`     | `11ms`     | `19ms`    | `26ms`      | `26ms`    | `29ms`    |

![List Operations](design/list-operations.png#gh-light-mode-only)![List Operations](design/list-operations-dark.png#gh-dark-mode-only)

### List Clearing

Clear the 1,000 item list by removing an item one at a time:

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   | **b4.3**   | **b5.1**   | **b6.0.1** | **b6.3**   | **RC1** | **RC1+JIT** | **RC-2** | **RC-2** |
|--------------------|------------|------------|------------|------------|------------|------------|------------|---------|-------------|----------|----------|
| Clearing           | `59000ms`  | `59000ms`  | `7700ms`   | `6100ms`   | `7100ms`   | `9000ms`   | `8800ms`   | `7500ms`| `115ms`     | `130ms`  | `134ms`  |

![List Clearing](design/list-clearing.png#gh-light-mode-only)![List Clearing](design/list-clearing-dark.png#gh-dark-mode-only)

## Digital Output Port Operations

### Digital Port initialization

Initializes three `DigitalOutputPort` instances, one for each of the onboard LED components and writes to them. 

| Operation              | **b3.5**  | **b3.6**  | **b3.7**  | **b4.3**  | **b5.1**  | **b6.0.1** | **b6.3**   | **RC1**    | **RC1+JIT** | **RC-2** | **RC-3** |
|------------------------|-----------|-----------|-----------|-----------|-----------|------------|------------|------------|-------------|----------|----------|
| Port initialization    | `2700ms`  | `2800ms`  | `2000ms`  | `500ms`   | `450ms`   | `460ms`    | `470ms`    | `480ms`    | `740ms`     | `704ms`  | `770ms`  |

![Port initialization](design/digital-output-initialize.png#gh-light-mode-only)![Port initialization](design/digital-output-initialize-dark.png#gh-dark-mode-only)

### Digital Port Writes

Alternate states to 3 Digital Output ports in 100 cycles. 

| Operation              | **b3.5**  | **b3.6**  | **b3.7**  | **b4.3**  | **b5.1**  | **b6.0.1** | **b6.3**   | **RC1**    | **RC1 w/ JIT** | **RC-2** | **RC-3** |
|------------------------|-----------|-----------|-----------|-----------|-----------|------------|------------|------------|----------------|----------|----------|
| 300 writes             | `48000ms`   `13000ms` | `150ms`   | `1400ms`  | `1330ms`  | `150ms`    | `140ms`    | `140ms`    | `50ms`         | `50ms`   | `54ms`   |

**NOTE**: Due to the drastic change of performance for this benchmark going from 4800 milliseconds (or 4.8 seconds) to 50 milliseconds (or 0.05 seconds), the graph below is expressed on a **logarithmic scale**.

![300 writes](design/digital-output-writes-log.png#gh-light-mode-only)![300 writes](design/digital-output-writes-log-dark.png#gh-dark-mode-only)

### Digital Port Average Time Per Write

Average time calculated between creating and writing on the digital output ports. 

| Operation              | **b3.5**  | **b3.6**  | **b3.7**  | **b4.3**  | **b5.1**  | **b6.0.1** | **b6.3**   | **RC1**    | **RC1 w/ JIT** | **RC-2** | **RC-3** |
|------------------------|-----------|-----------|-----------|-----------|-----------|------------|------------|------------|----------------|----------|----------|
| Avg time per write     | `159ms`   | `42ms`    | `0.5ms`   | `0.5ms`   | `0.44ms`  | `0.51ms`   | `0.46ms`   | `0.47ms`   | `0.16ms`       | `0.17ms` | `0.18ms` |

**NOTE**: Due to the drastic change of performance for this benchmark going from 159 milliseconds to 0.17 milliseconds, the graph below is expressed on a **logarithmic scale**.

![Avg time per write](design/digital-output-average-time-log.png#gh-light-mode-only)![Avg time per write](design/digital-output-average-time-log-dark.png#gh-dark-mode-only)

## Soft PWM Generation

Generates a PWM signal in software. Currently is a visual test. Run the test and note which was the last frequency change that was noticeable.

| Operation                        | **b3.5** | **b3.6** | **b3.7** | **b4.3** | **b5.1** | **b6.0.1** | **b6.3**   | **RC1**   | **RC1+JIT** |
|----------------------------------|----------|----------|----------|----------|----------|------------|------------|-----------|-------------|
| Maximum Frequency @ `50%` duty   | ~`50hz`  | ~`50hz`  | ~`100hz` | ~`100hz` | ~`100hz` | ~`100hz`   | ~`100hz`   |  ~`100Hz` | ~`1500Hz`   |

![Maximum Frequency @ 50% duty](design/soft-pwm-generation.png#gh-light-mode-only)![Maximum Frequency @ 50% duty](design/soft-pwm-generation-dark.png#gh-dark-mode-only)
