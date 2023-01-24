# Meadow Performance Benchmarks

Contains applications that measure the performance of Meadow, as well as the results of those tests.

This is primarily to track the progress of our performance improvements.

To validate, make sure to run application in `release` mode.

**Please Note** - Small variances will occur between runs and between boards.

## Benchmark Results

### Pi Calculation

Calculates pi (`3.14159..`) to [`x`] digits and records the amount of time it takes. Here are the results per release update:

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   | **b6.0.1** | **b6.3**   | **RC1**   | **RC1 w/ JIT** | **RC-2** |
|--------------------|------------|------------|------------|------------|------------|-----------|----------------|----------|
| 50 digit Pi        | `11`       | `11`       | `2.3`      | `1.8`      | `1.7`      | `2.3`     | `2.3`          | `2.2`    |
| 100 digit Pi       | `54`       | `54`       | `10.8`     | `8.9`      | `8.3`      | `11.2`    | `11.1`         | `10.1`   |
| 150 digit Pi       | `127`      | `126`      | `24.4`     | `20.6`     | `19.3`     | `26.3`    | `25.8`         | `23.4`   |

![Pi Calculation Graph](design/pi-calculation-dark.png)
 
### List Operations

Create a 1,000 item `List<int>`, and do perform basic list operations on it.

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   | **b4.3**   | **b5.1**   | **b6.0.1** | **b6.3**   | **RC1**   | **RC1 w/ JIT** | **RC-2** |
|--------------------|------------|------------|------------|------------|------------|------------|------------|-----------|----------------|----------|
| Instantiation      | `30`       | `30`       | `30`       | `19`       | `10`       | `11`       | `11`       | `5`       | `13`           | `14`     |
| Population         | `120`      | `120`      | `20`       | `44`       | `20`       | `21`       | `10`       | `21`      | `28`           | `29`     |
| Summation          | `130`      | `120`      | `30`       | `21`       | `19`       | `19`       | `11`       | `19`      | `26`           | `26`     |

![List Operations Graph](design/list-operations-dark.png)

| Operation          | **b3.5**   | **b3.6**   | **b3.7**   | **b4.3**   | **b5.1**   | **b6.0.1** | **b6.3**   | **RC1** | **RC1 w/ JIT** | **RC-2** |
|--------------------|------------|------------|------------|------------|------------|------------|------------|---------|----------------|----------|
| List clearing      | `59000`    | `59000`    | `7700`     | `6100`     | `7100`     | `9000`     | `8800`     | `7500`  | `115`          | `130`    |

![List Operations Graph](design/list-operations-clearing-dark.png)

### Digital Output Port Operations

Initializes three `DigitalOutputPort` instances, one for each of the onboard LED components and 
writes to them.

| Operation              | **b3.5**  | **b3.6**  | **b3.7**  | **b4.3**  | **b5.1**  | **b6.0.1** | **b6.3**   | **RC1**    | **RC1 w/ JIT** | **RC-2** |
|------------------------|-----------|-----------|-----------|-----------|-----------|------------|------------|------------|----------------|----------|
| Port initialization    | `2700`    | `2800`    | `2000`    | `500`     | `450`     | `460`      | `470`      | `480`      | `740`          | `704`    |
| 300 Port writes        | `48000`   | `13000`   | `150`     | `1400`    | `1330`    | `150`      | `140`      | `140`      | `50s`          | `50`     |
| Average time per write | `159`     | `42`      | `0.5`     | `0.5`     | `0.44`    | `0.51`     | `0.46`     | `0.47`     | `0.16`         | `0.17`   |

### SoftPwmGeneration

Generates a PWM signal in software. Currently is a visual test. Run the test and note which was 
the last frequency change that was noticeable.

| Operation                        | **b3.5** | **b3.6** | **b3.7** | **b4.3** | **b5.1** | **b6.0.1** | **b6.3**   | **RC1**   | **RC1 w/ JIT** |
|----------------------------------|----------|----------|----------|----------|----------|------------|------------|-----------|----------------|
| Maximum Frequency @ `50%` duty   | ~`50hz`  | ~`50hz`  | ~`100hz` | ~`100hz` | ~`100hz` | ~`100hz`   | ~`100hz`   |  ~`100Hz` | ~`1500Hz`      |
