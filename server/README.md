# Syrinscape Demo


## Instructions
- run server
	- python3 manage.py runserver
	- python3 manage.py runserver 0.0.0.0:7000
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
	- https://ap-southeast-2.console.aws.amazon.com/ecs/home?region=ap-southeast-2#/clusters/default/tasks
- public ip:
	- http://13.210.246.148:7000
- reset
	- http://13.210.246.148:7000/weapon?type=0