# Syrinscape Demo


## Instructions
- run server
	- python3 manage.py runserver
- example get weapon:
	- http://127.0.0.1:7000/weapon
- example set weapon:
	- http://127.0.0.1:7000/weapon?type=dinosaur
- curl example
	- curl -X GET http://127.0.0.1:7000/weapon?type=dinosaur

- build image
	- docker build -t mrchantey/syrinscape-demo-server .
- push
	- docker push mrchantey/syrinscape-demo-server
- stop aws task, it will restart automatically