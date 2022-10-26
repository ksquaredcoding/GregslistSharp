<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-3 col-md-4 my-3" v-for="j in jobs" :key="j.id">
        <div v-if="jobs.length > 0">
          <router-link :to="{
            name: 'Details',
            params: {
              id: j.id
            }
          }">
            <JobCard :job="j" />
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
import JobCard from '../components/JobCard.vue';
import { classifiedsService } from '../services/ClassifiedsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {

    async function getJobs() {
      try {
        await classifiedsService.getJobs()
      } catch (error) {
        Pop.error(error, '[GettingJobs]')
      }
    }

    onMounted(() => {
      getJobs()
    })

    return {
      jobs: computed(() => AppState.jobs),
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
  components: { JobCard }
}
</script>

<style scoped lang="scss">

</style>