#include <stdio.h>

static int arraySize = 6;

int * bubbleSort(int *numbers){
    for(int i = 1; i < arraySize; i = i+1){
        for(int k = 0; k < (arraySize - i); k = k+1){
            if(numbers[k] > numbers[k+1]){
                int temp = numbers[k];
                numbers[k] = numbers[k+1];
                numbers[k+1] = temp;
            }
        }
    }

    return numbers;
}

void main(int args[]) {
    int arrayo[6] = {6,2,3,4,1,5};
    int* sortedArrayo = bubbleSort(arrayo);

    for(int i = 0; i < arraySize; i = i + 1){
        printf("%i ", sortedArrayo[i]);
    }

    return;
}
