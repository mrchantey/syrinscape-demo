FROM python:3.8.5

WORKDIR /usr/src/app

RUN pip install django djangorestframework

COPY . .

CMD [ "python", "./manage.py","runserver", "0.0.0.0:7000"]