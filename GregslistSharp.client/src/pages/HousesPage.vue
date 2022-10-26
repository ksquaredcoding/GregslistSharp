<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-3 col-md-4 my-3" v-for="h in houses" :key="h.id">
        <div v-if="houses.length > 0">
          <router-link :to="{
            name: 'Details',
            params: {
              id: h.id
            }
          }">
            <HouseCard :house="h" />
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
import HouseCard from '../components/HouseCard.vue';
import { classifiedsService } from '../services/ClassifiedsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {

    async function getHouses() {
      try {
        await classifiedsService.getHouses()
      } catch (error) {
        Pop.error(error, '[GettingHouses]')
      }
    }

    onMounted(() => {
      getHouses()
    })

    return {
      houses: computed(() => AppState.houses),
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
  components: { HouseCard }
}
</script>

<style scoped lang="scss">

</style>

<!-- @deleteClassified="deleteClassified(c.id)"
:seller="h.seller" -->