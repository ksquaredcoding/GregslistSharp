import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"

class ClassifiedsService {

  async getCars() {
    const res = await api.get('api/cars')
    AppState.cars = res.data
  }

  async getHouses() {
    const res = await api.get('api/houses')
    AppState.houses = res.data
  }

  async getJobs() {
    const res = await api.get('api/jobs')
    AppState.jobs = res.data
  }

  async deleteCar(id) {
    await api.delete(`api/cars/${id}`)
    AppState.cars = AppState.cars.filter(c => c.id != id)
  }

  async deleteHouse(id) {
    await api.delete(`api/houses/${id}`)
    AppState.houses = AppState.houses.filter(h => h.id != id)
  }

  async deleteJob(id) {
    await api.delete(`api/jobs/${id}`)
    AppState.jobs = AppState.jobs.filter(j => j.id != id)
  }

  async getCarById(id) {
    const res = await api.get(`/api/cars/${id}`)
    AppState.activeClassified = res.data
  }

  async getHouseById(id) {
    const res = await api.get(`/api/Houses/${id}`)
    AppState.activeClassified = res.data
  }

  async getJobById(id) {
    const res = await api.get(`/api/Jobs/${id}`)
    AppState.activeClassified = res.data
  }

  async createClassified(formData) {
    switch (formData.listingType) {
      case "Car": {
        const res = await api.post('/api/cars', formData)
        AppState.cars.push(res.data)
      }
        break;
      case "House": {
        const res = await api.post('/api/houses', formData)
        AppState.houses.push(res.data)
      }
        break;
      case "Job": {
        const res = await api.post('/api/jobs', formData)
        AppState.jobs.push(res.data)
      }
        break;
    }
  }

}

export const classifiedsService = new ClassifiedsService()
