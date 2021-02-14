# syrinscape-demo
Tech demo for job interview at Syrinscape

## Server Instructions
- run server
	- pipenv shell
	- python3 manage.py runserver 0.0.0.0:7000
	- ifconfig to get wsl ip (inet X.X.X.X), 
	- ie 172.26.247.98:7000/weapon	
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

## Site Instructions

- Hosted on s3
	- http://syrinscape-demo.s3-website-ap-southeast-2.amazonaws.com/
- redirected from chantye
	- http://syrinscape-demo.chantey.org