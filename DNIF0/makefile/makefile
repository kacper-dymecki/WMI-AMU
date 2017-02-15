all: komp

komp: link

	gcc test.o -o test.a

link:
	
	gcc -c main.c -o test.o

clean:

	rm -rf test.*

test: all

	./test.a < dtest.txt > test.wynik
	diff test.wynik dtestwynik.txt

test_bad: all

	./test.a < ztest.txt > test.wynik
	diff test.wynik ztestwynik.txt

help:
	cat zadanie.txt


