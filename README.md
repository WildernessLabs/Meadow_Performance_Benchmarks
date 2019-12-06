# Meadow Performance Benchmarks

Contains applications that measure the performance of Meadow, as well as the results of those tests.

This is primarily to track the progress of our performance improvements; Meadow is currently slow because it executes .NET IL code in its interpreter. 

## Benchmark Results

### Pi Calculation



### List Operations

Create a 1,000 item `List<int>`, and do perform basic list operations on it.

| Operation          | Mark b3.5 | Mark b3.6 |
|--------------------|----------------|--------------|
| List instantiation | 30ms           |
| List population    | 120ms          |
| List summation     | 130ms          |
| List clearing      | 58,500ms       |

### Digital Output Port Operations

Initializes three `DigitalOutputPort` instances, one for each of the onboard LED components and 
writes to them.

| Operation              | Mark b3.5 | Mark b3.6 |
|------------------------|----------------|--------------|
| Port initialization    | 2,670ms        |
| 300 Port writes        | 4,760ms        |
| Average time per write | 15.9ms         |