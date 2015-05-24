all: run

frontend:
	cd frontend/ && ember build -prod

fastbuild: clean
	cp -r backend/ ./build/
	cp -r frontend/dist/* ./build/wwwroot

build: clean frontend fastbuild

clean:
	rm -rf ./build

run:
	dnx ./build kestrel

docker: build
	docker build -t turchenkoalex/voteapp .