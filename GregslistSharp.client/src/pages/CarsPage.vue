<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-3 col-md-4 my-3" v-for="c in cars" :key="c.id">
        <div v-if="cars.length > 0">
          <router-link :to="{
            name: 'Details',
            params: {
              id: c.id
            }
          }">
            <CarCard :car="c" @click="setActiveCar(c.id)" />
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';
import CarCard from '../components/CarCard.vue';
import { classifiedsService } from '../services/ClassifiedsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {

    async function getCars() {
      try {
        await classifiedsService.getCars()
      } catch (error) {
        Pop.error(error, '[GettingCars]')
      }
    }

    onMounted(() => {
      getCars()
    })

    return {
      cars: computed(() => AppState.cars),
      async setActiveCar(id) {
        try {
          await classifiedsService.getCarById(id)
        } catch (error) {
          Pop.error(error, '[SettingActive]')
        }
      }
      // async deleteClassified(id) {
      //   try {
      //     const yes = await Pop.confirm('Delete the Listing?')
      //     if (!yes) { return }
      //     await classifiedsService.deleteClassified(id)
      //   } catch (error) {
      //     Pop.error(error, '[Deleting Classified]')
      //   }
      // }
    };
  },
  components: { CarCard }
}
</script>

<style scoped lang="scss">

</style>