#include <stdio.h>

static int arraySize = 6;

int * insertionSort(int *numbers){
    for(int i = 1; i < arraySize; i = i+1){
        int slot = i;
        while(slot > 0 && numbers[slot] < numbers[slot - 1]){
            int temp = numbers[slot];
            numbers[slot] = numbers[slot-1];
            numbers[slot-1] = temp;
            
            slot = slot - 1;
        }
    }

    return numbers;
}

void main(int args[]) {
    int arrayo[6] = {6,2,3,4,1,5};
    int* sortedArrayo = insertionSort(arrayo);

    for(int i = 0; i < arraySize; i = i + 1){
        printf("%i ", sortedArrayo[i]);
    }

    return;
}
