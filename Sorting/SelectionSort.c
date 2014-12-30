#include <stdio.h>

static int arraySize = 6;

int * selectionSort(int *numbers){
    for(int i = 0; i < arraySize - 1; i = i+1){
        int min = i;
        for(int check = i + 1; check < arraySize; check = check + 1){
            if(numbers[check] < numbers[min]){
                min = check;
            }
        }

        int temp = numbers[min];
        numbers[min] = numbers[i];
        numbers[i] = temp;
    }

    return numbers;
}

void main(int args[]) {
    int arrayo[6] = {6,2,3,4,1,5};
    int* sortedArrayo = selectionSort(arrayo);

    for(int i = 0; i < arraySize; i = i + 1){
        printf("%i ", sortedArrayo[i]);
    }

    return;
}
